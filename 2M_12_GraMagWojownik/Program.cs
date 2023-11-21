namespace _2M_12_GraMagWojownik
{
    class Postac
    {
        protected string name;
        public int hp { get; protected set; }
        protected int sp;
        protected int mp;
        public Postac(string name, int hp, int sp, int mp = 0)
        {
            this.name = name;
            this.hp = hp;
            this.sp = sp;
            this.mp = mp;
        }

        public virtual int hit() { return 0; }
        public virtual void getHit(int n) {  }
        public override string ToString()
        {
            var m = mp > 0 ? $"mp: {mp};" : "";
            return $"{name}; hp: {hp}; sp: {sp}; " + m; ;
        }
    }
    class Rycerz : Postac
    {
        Random rnd = new Random();
        public Rycerz(string name, int hp, int sp, int mp = 0) 
            : base(name, hp, sp, mp)
        { }
        public override int hit()
        {
            int atak = (int)(1.0*rnd.Next(0, sp + 1) * hp / 100);
            Console.WriteLine($"{name} zadaje cos mieczem {atak}");
            return atak;
        }
        public override void getHit(int n) 
        {
            hp = hp - n;
            if(hp<0)
                hp = 0;
            Console.WriteLine($"{name} dostał cios za {n} hp, pozostało mu {hp}");

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }

    class Mag : Postac
    {
        Random rnd = new Random();
        
        public Mag(string name, int hp, int sp, int mp )
            : base(name, hp, sp, mp)
        { }
        public override int hit()
        {
            int atak = (rnd.Next(0, sp + 1) + rnd.Next(0, mp+1) )* hp / 100;
            Console.WriteLine($"{name} zadaje cos magiczny {atak}" );
            return atak;
        }
        public override void getHit(int n)
        {
            hp = hp - n;
            if (hp < 0)
                hp = 0;
            Console.WriteLine($"{name} dostał cios za {n} hp, pozostało mu {hp}");

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Mag harry = new Mag("Harry Potter", 100, 10, 20);
            Console.WriteLine(harry);
            Rycerz conan = new Rycerz("Conan Barbarzyńca", 100, 30);
            Console.WriteLine(conan);

            while(true)
            {
                conan.getHit(harry.hit());
                if (conan.hp == 0)
                    break;
                harry.getHit(conan.hit());
                if(harry.hp == 0)
                    break;
            }
            if (harry.hp == 0)
                Console.WriteLine("Wygrał Conan");
            else
                Console.WriteLine("Wygrał Harry");
                
        }
    }
}
