using Data;
using Interface;

namespace Service
{
    public class Test: ITest
    {
        private readonly DataContext _context;

        public Test(DataContext context)
        {
            _context = context;
        }

        public bool connection()
        {
            return _context.Database.CanConnect();
        }
    }
}
