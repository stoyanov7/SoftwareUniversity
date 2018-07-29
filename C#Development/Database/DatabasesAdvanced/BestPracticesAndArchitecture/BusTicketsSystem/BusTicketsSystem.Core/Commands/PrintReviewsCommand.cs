namespace BusTicketsSystem.Core.Commands
{
    using System.Text;
    using Contracts;
    using Models;
    using Services.Contracts;

    public class PrintReviewsCommand : ICommand
    {
        private readonly IBusCompanyService service;

        public PrintReviewsCommand(IBusCompanyService service)
        {
            this.service = service;
        }

        public string Execute(string[] args)
        {
            var busCompanyId = int.Parse(args[0]);
            var busCompany = this.service.ById<BusCompany>(busCompanyId);

            var sb = new StringBuilder();
            foreach (var item in busCompany.Reviews)
            {
                sb.AppendLine($"{item.Grade} {item.DateAndTimeOfPublishing}\r\n{item.Customer.FirstName} {item.Customer.LastName}\r\n {item.Content}");
            }

            return sb.ToString().Trim();
        }
    }
}