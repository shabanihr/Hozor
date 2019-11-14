using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hozor.DataLayer.Models
{
    public partial class CEmployees
    {
        public CEmployees()
        {
            EventControlLoadings = new HashSet<EventControlLoadings>();
            EventControlLooks = new HashSet<EventControlLooks>();
            EventControlServices = new HashSet<EventControlServices>();
            EventControlWorkNighits = new HashSet<EventControlWorkNighits>();
            EventGuardLists = new HashSet<EventGuardLists>();
            EventGuardShift = new HashSet<EventGuardShift>();
            EventGuardStatus = new HashSet<EventGuardStatus>();
            EventPatrol = new HashSet<EventPatrol>();
            TcCompanyTraffics = new HashSet<TcCompanyTraffics>();
            TeTraffic = new HashSet<TeTraffic>();
            TmEmployeeMeetingsHost = new HashSet<TmEmployeeMeetings>();
            TmEmployeeMeetingsMeeter = new HashSet<TmEmployeeMeetings>();
            TmVisitorMeetings = new HashSet<TmVisitorMeetings>();
            TvVisitorTraffic = new HashSet<TvVisitorTraffic>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "شماره پرسنلي")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PersonalId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگي")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Family { get; set; }

        [Display(Name = "پست سازماني")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Job { get; set; }

        [Display(Name = "رده سازماني")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "پست سازماني نمي تواند بيشتر 100 كاراكتر باشد")]
        public string Category { get; set; }

        public byte[] Image { get; set; }

        [Display(Name = "در حال كار")]
        public bool IsActive { get; set; }

        [Display(Name = "شماره عكس")]
        public int? ImageNumber { get; set; }

        [Display(Name = "مشخصات عكس")]
        public string FerstName { get; set; }

        [Display(Name = "تاريخ شروع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "تاريخ پايان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "واحد سازماني")]
        public string Section { get; set; }

        [Display(Name = "عكس")]
        public string ImageName { get; set; }

        public ICollection<EventControlLoadings> EventControlLoadings { get; set; }
        public ICollection<EventControlLooks> EventControlLooks { get; set; }
        public ICollection<EventControlServices> EventControlServices { get; set; }
        public ICollection<EventControlWorkNighits> EventControlWorkNighits { get; set; }
        public ICollection<EventGuardLists> EventGuardLists { get; set; }
        public ICollection<EventGuardShift> EventGuardShift { get; set; }
        public ICollection<EventGuardStatus> EventGuardStatus { get; set; }
        public ICollection<EventPatrol> EventPatrol { get; set; }
        public ICollection<TcCompanyTraffics> TcCompanyTraffics { get; set; }
        public ICollection<TeTraffic> TeTraffic { get; set; }
        public ICollection<TmEmployeeMeetings> TmEmployeeMeetingsHost { get; set; }
        public ICollection<TmEmployeeMeetings> TmEmployeeMeetingsMeeter { get; set; }
        public ICollection<TmVisitorMeetings> TmVisitorMeetings { get; set; }
        public ICollection<TvVisitorTraffic> TvVisitorTraffic { get; set; }
    }
}
