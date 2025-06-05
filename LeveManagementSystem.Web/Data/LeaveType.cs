using System.ComponentModel.DataAnnotations.Schema;

namespace LeveManagementSystem.Web.Data
{
    public class LeaveType 
    {
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(150)")] 
        //we can also use [MaxLength(150)]
        public string Name { get; set; }
        public int NumberOfDays { get; set; }
    }
}
