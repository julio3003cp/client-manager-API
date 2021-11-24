namespace cli_manager_API.Models.DTOs.Cli
{
    public struct PageResult
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
    }
}
