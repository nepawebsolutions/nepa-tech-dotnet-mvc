using NEPATechDotnetCoreMVC.Models.MockUsers;
using NEPATechDotnetCoreMVC.Models.Project;
using NEPATechDotnetCoreMVC.Models.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.ViewModel
{
    public class MembersViewModel
    {
        public IEnumerable<MemberProfileViewModel> Members { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public Pager Pager { get; set; }
    }

    public class Pager
    {
        //Controls the pagination for the members list
        public Pager(int totalItems, int? page, int pageSize = 10)
        {
            // calculating the total, start and end pages
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5; // shows the previous 5 classes if possible
            var endPage = currentPage + 4; //shows the next 4 page numbers if possible

            if(startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if(endPage > totalPages)
            {
                endPage = totalPages;
                if(endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            NextPage =  CurrentPage + 1;
            PreviousPage =  CurrentPage - 1;


            
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int NextPage { get; private set; }
        public int PreviousPage { get; private set; }
    }
}
