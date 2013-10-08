using Blog.Core;
using Blog.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EntitiesModel context = new EntitiesModel())
            {
                // Supprime la BDD si elle existe
                context.Database.Delete();

                // Création du Catégorie
                CategoryDTO category = new CategoryDTO();
                category.Name = ".NET";

                // Ajout au context et sauvegarde en base de données
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
    }
}
