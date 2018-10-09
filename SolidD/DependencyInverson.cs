﻿using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace SolidD
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            //foreach (var r in relations.Where(
            //                                x => x.Item1.Name == name &&
            //                                     x.Item2 == Relationship.Parent))
            //{
            //    yield return r.Item3;
            //}

            return relations.Where(x => x.Item1.Name == name &&
                                     x.Item2 == Relationship.Parent).Select(r => r.Item3);
        }

        //public List<(Person, Relationship, Person)> Relations => relations;
    }

    public class DependencyInverson
    {
        //public DependencyInverson(Relationships relationships)
        //{
        //    var relations = relationships.Relations;
        //    foreach (var r in relations.Where(
        //                                    x => x.Item1.Name == "John" &&
        //                                         x.Item2 == Relationship.Parent))
        //    {
        //        WriteLine($"John has a child called {r.Item3.Name}");
        //    }
        //}

        public DependencyInverson(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
                WriteLine($"John has a child called {p.Name}");
        }
        
        static void Main(string[] args)
        {
            Person parent = new Person { Name = "John" };
            Person child1 = new Person { Name = "Chris" };
            Person child2 = new Person { Name = "Mary" };

            Relationships relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);
            new DependencyInverson(relationships);
            ReadKey();
        }
    }
}
