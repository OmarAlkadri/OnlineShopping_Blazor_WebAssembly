using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.QuestionssDto
{
    public class QuestionsDto
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public Guid CastomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
