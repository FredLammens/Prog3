namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            WhereCursOef.ShowFilter1(StudentenLijst.L);
            WhereCursOef.ShowFilter2(StudentenLijst.L);
            OrderingCursOef.Order1(StudentenLijst.L);
            OrderingCursOef.Order2(StudentenLijst.L);
            OrderingCursOef.Order3(StudentenLijst.L);
            OrderingCursOef.Order4(StudentenLijst.L);
            SelectCursOef.Select1(StudentenLijst.L);
            SelectCursOef.Select2(StudentenLijst.L);
            SelectCursOef.Select3(StudentenLijst.L);
            SelectCursOef.Select4(StudentenLijst.L);
            SelectCursOef.Select5(StudentenLijst.L);
            GroupByCursOef.group1(StudentenLijst.L);
            GroupByCursOef.group2(StudentenLijst.L);
            GroupByCursOef.group3(StudentenLijst.L);
            FiLaTaSkEl.ElementAt(StudentenLijst.L);
            FiLaTaSkEl.FirstLast(StudentenLijst.L);
            FiLaTaSkEl.Take(StudentenLijst.L);
            FiLaTaSkEl.Skip(StudentenLijst.L);
            SetOperatorOef set = new SetOperatorOef();
            set.intersect();
            set.union();
            set.except();
            JoinCursOef join = new JoinCursOef();
            join.Join();
            join.groupJoin();
            AnyCursOef.IsAllAny();
        }
    }
}
