namespace ChrAPI1.DTO
{
    public class DepartmentWithEmps
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public string DeptManager { get; set; }
        public List<string> EmpsName { get; set;}
    }
}
