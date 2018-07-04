namespace Stations.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Dto.Import;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Enumeration;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportStations(StationsDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var deserializedStations = JsonConvert.DeserializeObject<StationDto[]>(jsonString);
            var validStations = new List<Station>();

            foreach (var stationDto in deserializedStations)
            {

                // If the town name is not given, insert it with the same value as the station name
                if (stationDto.Town == null)
                {
                    stationDto.Town = stationDto.Name;
                }

                // If a station with the same name already exists, ignore the entity.
                if (validStations.Any(s => s.Name == stationDto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                // If any other validation error occurs
                if (!IsValid(stationDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                
                var station = Mapper.Map<Station>(stationDto);

                validStations.Add(station);

                sb.AppendLine(string.Format(SuccessMessage, stationDto.Name));
            }

            context.Stations.AddRange(validStations);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportClasses(StationsDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var deserializedSeatClasses = JsonConvert.DeserializeObject<SeatingClassDto[]>(jsonString);
            var validSeatingClasses = new List<SeatingClass>();

            foreach (var seatingClassDto in deserializedSeatClasses)
            {
                // If a seating class with the same name or abbreviation already exists, ignore the entity.
                if (validSeatingClasses.Any(sc =>
                    sc.Name == seatingClassDto.Name ||
                    sc.Abbreviation == seatingClassDto.Abbreviation))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                // If any other validation error occurs
                if (!IsValid(seatingClassDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatingClass = Mapper.Map<SeatingClass>(seatingClassDto);
                validSeatingClasses.Add(seatingClass);
                sb.AppendLine(string.Format(SuccessMessage, seatingClass.Name));
            }

            context.SeatingClasses.AddRange(validSeatingClasses);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

		public static string ImportTrains(StationsDbContext context, string jsonString)
		{
            var sb = new StringBuilder();
            var deserializedTrains = JsonConvert.DeserializeObject<TrainDto[]>(jsonString, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var validTrains = new List<Train>();

            foreach (var trainsDto in deserializedTrains)
            {
                if (!IsValid(trainsDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var trainAlreadyExist = validTrains.Any(t => t.TrainNumber == trainsDto.TrainNumber);
                if (trainAlreadyExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatsAreValid = trainsDto.Seats.All(IsValid);
                if (!seatsAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatingClassesAreValid = trainsDto
                    .Seats
                    .All(s => context
                        .SeatingClasses
                        .Any(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation));

                if (!seatingClassesAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var type = Enum.Parse<TrainType>(trainsDto.Type);

                var trainSeats = trainsDto.Seats.Select(s => new TrainSeat
                {
                    SeatingClass = context
                        .SeatingClasses
                        .SingleOrDefault(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation),
                    Quantity = s.Quantity.Value
                })
                .ToArray();

                var train = new Train
                {
                    TrainNumber = trainsDto.TrainNumber,
                    Type = type,
                    TrainSeats = trainSeats
                };

                validTrains.Add(train);
                sb.AppendLine(string.Format(SuccessMessage, trainsDto.TrainNumber));
            }

            context.Trains.AddRange(validTrains);
		    context.SaveChanges();

		    var result = sb.ToString().TrimEnd();
		    return result;
		}

        public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var deserializeTrips = JsonConvert.DeserializeObject<TripDto[]>(jsonString, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var validTrips = new List<Trip>();

            foreach (var tripDto in deserializeTrips)
            {
                if (!IsValid(tripDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                // Check for the existence of trains and stations in database
                var train = context
                    .Trains
                    .SingleOrDefault(t => t.TrainNumber == tripDto.Train);

                var originStation = context
                    .Stations
                    .SingleOrDefault(os => os.Name == tripDto.OriginStation);

                var destinationStation = context
                    .Stations
                    .SingleOrDefault(ds => ds.Name == tripDto.DestinationStation);

                if (train == null || 
                    originStation == null || 
                    destinationStation == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var departureTime = DateTime.ParseExact(tripDto.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                var arrivalTime = DateTime.ParseExact(tripDto.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                // Time Difference may be null or be represented in format "hh:mm"
                TimeSpan timeDifference; 
                if (tripDto.TimeDifference != null)
                {
                    timeDifference = TimeSpan.ParseExact(tripDto.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture);
                }

                // Check if departure time is before the arrival one
                if (departureTime > arrivalTime)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var status = Enum.Parse<TripStatus>(tripDto.Status);

                var trip = new Trip
                {
                    Train = train,
                    OriginStation = originStation,
                    DestinationStation = destinationStation,
                    DepartureTime =  departureTime,
                    ArrivalTime = arrivalTime,
                    Status =  status,
                    TimeDifference = timeDifference
                };

                validTrips.Add(trip);
                sb.AppendLine($"Trip from {tripDto.OriginStation} to {tripDto.DestinationStation} imported.");
            }

            context.Trips.AddRange(validTrips);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

		public static string ImportCards(StationsDbContext context, string xmlString)
		{
            var sb = new StringBuilder();
		    var serializer = new XmlSerializer(typeof(CardDto[]), new XmlRootAttribute("Cards"));
		    var deserializedCards = (CardDto[])serializer
		        .Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
		    var validCards = new List<CustomerCard>();

		    foreach (var cardDto in deserializedCards)
		    {
		        if (!IsValid(cardDto))
		        {
                    sb.AppendLine(FailureMessage);
                    continue;
		        }

		        var cardType = Enum.TryParse<CardType>(cardDto.CardType, out var card) 
		            ? card : CardType.Normal;

		        var customerCard = new CustomerCard
		        {
		            Name = cardDto.Name,
		            Type = cardType,
                    Age = cardDto.Age
		        };

                validCards.Add(customerCard);
		        sb.AppendLine(string.Format(SuccessMessage, customerCard.Name));
		    }

            context.Cards.AddRange(validCards);
		    context.SaveChanges();

		    var result = sb.ToString().TrimEnd();
		    return result;
		}

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(TicketDto[]), new XmlRootAttribute("Tickets"));
            var deserializedTickets = (TicketDto[])serializer
                .Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();

            var validTickets = new List<Ticket>();
            foreach (var ticketDto in deserializedTickets)
            {
                if (!IsValid(ticketDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var departureTime =
                    DateTime.ParseExact(ticketDto.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var trip = context.Trips
                    .Include(t => t.OriginStation)
                    .Include(t => t.DestinationStation)
                    .Include(t => t.Train)
                    .ThenInclude(t => t.TrainSeats)
                    .SingleOrDefault(t => t.OriginStation.Name == ticketDto.Trip.OriginStation &&
                                          t.DestinationStation.Name == ticketDto.Trip.DestinationStation &&
                                          t.DepartureTime == departureTime);
                if (trip == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CustomerCard card = null;
                if (ticketDto.Card != null)
                {
                    card = context
                        .Cards
                        .SingleOrDefault(c => c.Name == ticketDto.Card.Name);

                    if (card == null)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }
                }

                var seatingClassAbbreviation = ticketDto.Seat.Substring(0, 2);
                var quantity = int.Parse(ticketDto.Seat.Substring(2));

                var seatExists = trip.Train.TrainSeats
                    .SingleOrDefault(s => s.SeatingClass.Abbreviation == seatingClassAbbreviation && 
                                          quantity <= s.Quantity);

                if (seatExists == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seat = ticketDto.Seat;

                var ticket = new Ticket
                {
                    Trip = trip,
                    CustomerCard = card,
                    Price = ticketDto.Price,
                    SeatingPlace = seat
                };

                validTickets.Add(ticket);

                sb.AppendLine(string.Format("Ticket from {0} to {1} departing at {2} imported.",
                    trip.OriginStation.Name,
                    trip.DestinationStation.Name,
                    trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
            }

            context.Tickets.AddRange(validTickets);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        private static bool IsValid(object obj)
	    {
	        var validationContext = new ValidationContext(obj);
	        var validationResult = new List<ValidationResult>();

	        var isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);

	        return isValid;
	    }
    }
}