namespace FastFood.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Dto.Import;
    using Models;
    using Models.Enums;
    using Newtonsoft.Json;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var deserializedEmployees = JsonConvert.DeserializeObject<EmoloyeeDto[]>(jsonString);
            var validEmployees = new List<Employee>();
            var sb = new StringBuilder();

            foreach (var employeeDto in deserializedEmployees)
            {
                // If any validation errors occur
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                // If a position doesn’t exist yet, create it. 
                var position = validEmployees
                    .SingleOrDefault(p => p.Position.Name == employeeDto.Position)
                    ?.Position;

                if (position == null)
                {
                    position = new Position { Name = employeeDto.Position };
                }

                if (!IsValid(position))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var currentEmployee = new Employee
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    Position = position
                };

                validEmployees.Add(currentEmployee);
                sb.AppendLine(string.Format(SuccessMessage, currentEmployee.Name));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var deserializeItems = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);
            var validItems = new List<Item>();
            var sb = new StringBuilder();

            foreach (var itemDto in deserializeItems)
            {
                var isValidItem = IsValid(itemDto);
                var itemAlreadyExist = validItems.Any(i => i.Name == itemDto.Name);

                if (!isValidItem || itemAlreadyExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var category = validItems
                    .FirstOrDefault(c => c.Category.Name == itemDto.Category)
                    ?.Category;

                if (category == null)
                {
                    category = new Category { Name = itemDto.Category };
                }

                var currentItem = new Item
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Category = category
                };

                validItems.Add(currentItem);
                sb.AppendLine(string.Format(SuccessMessage, currentItem.Name));
            }

            context.AddRange(validItems);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));
            var deserializedOrders = (OrderDto[])serializer
                .Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            var validOrders = new List<Order>();
            var sb = new StringBuilder();

            foreach (var orderDto in deserializedOrders)
            {
                if (!IsValid(orderDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var employee = context
                    .Employees
                    .FirstOrDefault(e => e.Name == orderDto.Employee);

                if (employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var dateTime = DateTime.ParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                var type = Enum.Parse<OrderType>(orderDto.Type);

                //•	If any of the order’s items do not exist, do not import the order.
                var itemsExist = orderDto
                    .Items
                    .All(i => context.Items.Any(it => it.Name == i.Name));

                if (!itemsExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var orderItems = new List<OrderItem>();

                var currentOrder = new Order
                {
                    Customer = orderDto.Customer,
                    Employee = employee,
                    DateTime = dateTime,
                    Type = type
                };

                foreach (var oi in orderDto.Items)
                {
                    var item = context
                        .Items
                        .FirstOrDefault(i => i.Name == oi.Name);

                    var orderItem = new OrderItem
                    {
                        Item = item,
                        Order = currentOrder,
                        Quantity = oi.Quantity
                    };

                    orderItems.Add(orderItem);
                }

                currentOrder.OrderItems = orderItems;

                validOrders.Add(currentOrder);
                sb.AppendLine($"Order for {currentOrder.Customer} on {dateTime:dd/MM/yyyy HH:mm} added");
            }

            context.Orders.AddRange(validOrders);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }
        
        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}
