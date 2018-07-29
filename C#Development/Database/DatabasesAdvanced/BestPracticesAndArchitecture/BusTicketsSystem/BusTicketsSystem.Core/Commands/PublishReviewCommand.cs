namespace BusTicketsSystem.Core.Commands
{
    using Contracts;
    using Services.Contracts;

    public class PublishReviewCommand : ICommand
    {
        private readonly IReviewService reviewService;

        public PublishReviewCommand(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public string Execute(string[] args)
        {
            var customerId = int.Parse(args[0]);
            var grade = float.Parse(args[1]);
            var busCompanyName = args[2];
            var content = args[3];

            var review = this.reviewService.Create(customerId, grade, busCompanyName, content);

            return $"Customer {review.Customer.FirstName} {review.Customer.LastName} published review for company {busCompanyName}";
        }
    }
}