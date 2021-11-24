namespace cli_manager_API.Models.DTOs
{
    public struct Filter
    {
        public Filter(int id, int state)
        {
            Id = id;
            State = state;
        }

        public int Id { get; set; }
        public int State { get; set; }
    }
}
