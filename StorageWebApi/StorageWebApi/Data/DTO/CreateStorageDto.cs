namespace StorageWebApi.Data.DTO
{
    public class CreateStorageDto
    {
        public string Sname { get; set; }
        public string Sdescription { get; set; }
        public int Sarea { get; set; }
        public Guid? OwnerId { get; set; } 
    }
}
