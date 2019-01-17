namespace FN.Store.Api.Controllers.ViewModels
{
    public class Pagination
    {
        public Pagination(int total, object data)
        {
            this.Total = total;
            this.Data = data;
        }
        public int Total { get; private set; }
        public object Data { get; private set; }

    }
}
