namespace BusTicketsSystem.Services
{
    using Contracts;
    using Data;
    using Models;

    public class ReviewService : IReviewService
    {
        private readonly BusTicketsSystemContext context;
        private readonly ICustomerService customerService;
        private readonly IBusCompanyService busCompanyService;

        public ReviewService(BusTicketsSystemContext context, ICustomerService customerService, IBusCompanyService busCompanyService)
        {
            this.context = context;
            this.customerService = customerService;
            this.busCompanyService = busCompanyService;
        }

        public Review Create(int customerId, float grade, string busCompanyName, string content)
        {
            var customer = this.customerService.ById<Customer>(customerId);
            var busCompany = this.busCompanyService.ByName<BusCompany>(busCompanyName);

            var review = new Review
            {
                BusCompany = busCompany,
                BusCompanyId = busCompany.Id,
                Customer = customer,
                CustomerId = customerId,
                Grade = grade,
                Content = content
            };

            this.context.Reviews.Add(review);
            this.context.SaveChanges();

            return review;
        }
    }
}