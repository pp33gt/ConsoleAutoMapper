using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration;

namespace ConsoleAutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();
            C1ToC2(mapper);

            C2ToC1(mapper);

        }

        private static void C1ToC2(IMapper mapper)
        {
            var c1 = new Class1() { Id = 5, Name = "class1", Names = new string[] { "foo", "bar" } };

            var c2 = mapper.Map(c1, typeof(Class1), typeof(Class2));
        }

        private static void C2ToC1(IMapper mapper)
        {
            var c2 = new Class2() { Id = 5, Name = "class1", Names = new string[] { "foo", "bar" } };

            var c1 = mapper.Map(c2, typeof(Class2), typeof(Class1));
            var c11 = mapper.Map<Class1>(c2);
        }

    }


    public class Class1
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string[] Names { get; set; }
    }

    public class Class2
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string[] Names { get; set; }
    }


    internal class MappingProfile : Profile
    {
        internal MappingProfile()
        {
            Configure();
        }
        protected void Configure()
        {
            CreateMap<Class1, Class2>();
            CreateMap<Class2, Class1>();
        }
    }
}
