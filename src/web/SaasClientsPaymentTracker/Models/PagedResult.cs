﻿namespace SaasClientsPaymentTracker.Models
{
    public class PagedResult<T>
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<T> Data { get; set; } = new();
        public decimal ClientsTotalPaidAmount { get; set; }
    }
}
