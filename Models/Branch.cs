using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPPR_Demo.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string MondayStartHour { get; set; }
        public string TuesdayStartHour { get; set; }
        public string WednesdayStartHour { get; set; }
        public string ThursdayStartHour { get; set; }
        public string FridayStartHour { get; set; }
        public string SaturdayStartHour { get; set; }
        public string SundayStartHour { get; set; }
        public string MondayEndHour { get; set; }
        public string TuesdayEndHour { get; set; }
        public string WednesdayEndHour { get; set; }
        public string ThursdayEndHour { get; set; }
        public string FridayEndHour { get; set; }
        public string SaturdayEndHour { get; set; }
        public string SundayEndHour { get; set; }
        public string Services { get; set; }
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public class BranchChangeRequest : Branch
    {
        public long ChangeRequestId { get; set; }
    }
}
