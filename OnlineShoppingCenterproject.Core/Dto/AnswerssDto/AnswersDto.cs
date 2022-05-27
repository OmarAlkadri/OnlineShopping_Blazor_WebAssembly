using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.AnswerssDto
{
    public class AnswersDto
    {
        public Guid Id { get; set; }
        public string answers { get; set; }
        public Guid CompanyId { get; set; }
        public Guid QuestionsId { get; set; }
    }
}
