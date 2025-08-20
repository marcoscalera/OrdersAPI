public record OrderSummaryDto
(
    int OrderId,
    string CustomerName, // concatenation of first and last name
    string Status,
    decimal TotalAmount
);