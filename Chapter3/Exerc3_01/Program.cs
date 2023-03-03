using System;

namespace Chapter3.Exerc3_01
{
    public delegate bool DateValidationHandler(DateTime dateTime);

    public class Order
    {
        public DateTime orderDate { get; set; }
        public DateTime deliveryDate { get; set; }

        private readonly DateValidationHandler orderDateValidator;
        private readonly DateValidationHandler deliveryDateValidator;

        public bool IsValid() => orderDateValidator(orderDate) && deliveryDateValidator(deliveryDate);

        public Order(DateValidationHandler orderDateValidator, DateValidationHandler deliveryDateValidator)
        {
            this.orderDateValidator = orderDateValidator;
            this.deliveryDateValidator = deliveryDateValidator;
        }
    }

    public static class Program
    {
        private static bool IsWeekendDate(DateTime date)
        {
            Console.WriteLine("Called IsWeekendDate");
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
        private static bool IsPastDate(DateTime date)
        {
            Console.WriteLine("Called IsPastDate");
            return date < DateTime.Today;
        }

        public static void Main()
        {
            var orderValidator = new DateValidationHandler(IsPastDate);
            var deliverValidator = new
            DateValidationHandler(IsWeekendDate);

            var order = new Order(orderValidator, deliverValidator)
            {
                orderDate = DateTime.Today.AddDays(-10),
                deliveryDate = new DateTime(2020, 12, 31)
            };

            Console.WriteLine($"Ordered: {order.orderDate:dd-MMM-yy}");
            Console.WriteLine($"Delivered: {order.deliveryDate:dd-MMM-yy}");
            Console.WriteLine($"IsValid: {order.IsValid()}");

        }
    }
}