using System.Collections.Generic;

namespace ABCMoneyTransfer.DTOs
{
    public class ForexResponse
    {
        public ForexStatus Status { get; set; }
        public ForexErrors Errors { get; set; }
        public ForexParams Params { get; set; }
        public ForexData Data { get; set; }
        public ForexPagination Pagination { get; set; }
    }

    public class ForexStatus
    {
        public int Code { get; set; }
    }

    public class ForexErrors
    {
        public object Validation { get; set; }
    }

    public class ForexParams
    {
        public string Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string PostType { get; set; }
        public string PerPage { get; set; }
        public string Page { get; set; }
        public string Slug { get; set; }
        public string Q { get; set; }
    }

    public class ForexData
    {
        public List<ForexPayload> Payload { get; set; }
    }

    public class ForexPayload
    {
        public string Date { get; set; }
        public string PublishedOn { get; set; }
        public string ModifiedOn { get; set; }
        public List<ForexRate> Rates { get; set; }
    }

    public class ForexRate
    {
        public ForexCurrency Currency { get; set; }
        public string Buy { get; set; }
        public string Sell { get; set; }
    }

    public class ForexCurrency
    {
        public string Iso3 { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
    }

    public class ForexPagination
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public ForexLinks Links { get; set; }
    }

    public class ForexLinks
    {
        public object Prev { get; set; }
        public object Next { get; set; }
    }
}
