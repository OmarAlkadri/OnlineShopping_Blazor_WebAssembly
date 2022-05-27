using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Entities
{
    public class Answers
    {
        public Guid Id { get; set; }
        public string answers { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Guid? QuestionsId { get; set; }
        public Questions? Questions { get; set; }
    }
}
