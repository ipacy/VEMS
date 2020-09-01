namespace VEMS.Models
{
    public class ApiResponsePaging<T> : ApiResponse<T>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
    }
}
