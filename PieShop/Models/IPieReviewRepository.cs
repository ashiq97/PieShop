using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public interface IPieReviewRepository
    {
        void AddPieReview(PieReview pieReview);
        IEnumerable<PieReview> GetReviewsForPie(int pieId);
    }
}
