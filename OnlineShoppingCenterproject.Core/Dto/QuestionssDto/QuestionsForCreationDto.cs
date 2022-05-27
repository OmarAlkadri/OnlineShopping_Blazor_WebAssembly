using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Dto.QuestionssDto
{
    public class QuestionsForCreationDto
    {
        public string Question { get; set; }
        public int CastomerId { get; set; }
        public int ProductId { get; set; }
    }
}
