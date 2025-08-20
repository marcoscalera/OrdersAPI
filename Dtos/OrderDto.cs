public record OrderDto(
    int Id,
    string FirstName,
    string LastName,
    string Status,
    DateTime CreatedAt,
    decimal TotalCost
);
