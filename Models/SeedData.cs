using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace SSDAssignmentBOX.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookContext(serviceProvider.GetRequiredService<DbContextOptions<BookContext>>()))
            {
                //Look for any books
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }
                else
                {
                    context.Book.AddRange(
                    //Book1
                    new Book
                    {
                        ISBN = "9780439554930",
                        Title = "Harry Potter and the Philosopher's Stone",
                        Author = "J.K. Rowling",
                        Summary = "Harry Potter's life is miserable. His parents are dead and he's stuck with his heartless relatives, who force him to live in a tiny closet under the stairs. But his fortune changes when he receives a letter that tells him the truth about himself: he's a wizard. A mysterious visitor rescues him from his relatives and takes him to his new home, Hogwarts School of Witchcraft and Wizardry.",
                        DatePublished = DateTime.Parse("12/7/2018"),
                        Genre = "Fantasy",
                        Language = "English",
                        Characters = "Draco Malfoy, Ron Weasley, Petunia Dursley, Vernon Dursley, Dudley Dursley, Albus Dumbledore, Severus Snape, Quirinus Quirrell, Rubeus Hagrid, Lord Voldemort, Minerva McGonagall, Neville Longbottom, Fred Weasley, George Weasley, Percy Weasley, Filius Flitwick, Pomona Sprout, Molly Weasley, Poppy Pomfrey, Oliver Wood, Parvati Patil, Lavender Brown, Dean Thomas, James Potter, Lily Potter, Seamus Finnigan, Garrick Ollivander, Rolanda Hooch, Katie Bell, Dedalus Diggle, Harry Potter, Hermione Granger",
                        DateReceived = DateTime.Parse("20/7/2018"),
                        Location = "Bukit Panjang Library",
                        Availability = "Available"
                    },
                    //Book2
                    new Book
                    {
                        ISBN = "9780316015844",
                        Title = "Twilight",
                        Author = "Stephenie Meyer",
                        Summary = "About three things I was absolutely positive. First,Edward was a vampire. Second, there was a part of him—and I didn't know how dominant that part might be—that thirsted for my blood. And third,I was unconditionally and irrevocably in love with him.",
                        DatePublished = DateTime.Parse("6/9/2006"),
                        Genre = "Horror",
                        Language = "English",
                        Characters = "Edward Cullen, Jacob Black, Laurent, Renee, Bella Swan, Billy Black, Esme Cullen, Alice Cullen, Jasper Hale, Carlisle Cullen, Emmett Cullen, Rosalie Hale, Charlie Swan, Mike Newton, Jessica Stanley, Angela Weber, Tyler Crowley",
                        DateReceived = DateTime.Parse("20/7/2010"),
                        Location = "Clementi Library",
                        Availability = "Not Available"
                    },
                    //Book3
                    new Book
                    {
                        ISBN = "9780399562303",
                        Title = "Alone Time: Four Seasons, Four Cities, and the Pleasures of Solitude",
                        Author = "Stephanie Rosenbloom",
                        Summary = "In our increasingly frantic daily lives, many people are genuinely fearful of the prospect of solitude, but time alone can be both rich and restorative, especially when travelling. Through on-the-ground reporting and recounting the experiences of artists, writers, and innovators who cherished solitude, Stephanie Rosenbloom considers how being alone as a traveller--and even in one's own city--is conducive to becoming acutely aware of the sensual details of the world--patterns, textures, colors, tastes, sounds--in ways that are difficult to do in the company of others.",
                        DatePublished = DateTime.Parse("5/6/2018"),
                        Genre = "Travel",
                        Language = "English",
                        Characters = "Nil",
                        DateReceived = DateTime.Parse("20/7/2018"),
                        Location = "Woodlands Library",
                        Availability = "Available"
                    },
                    //Book4
                    new Book
                    {
                        ISBN = "9780807047415",
                        Title = "White Fragility: Why It is So Hard for White People to Talk About Racism",
                        Author = "Robin DiAngelo,  Michael Eric Dyson (Foreword)",
                        Summary = "Groundbreaking book exploring the counterproductive reactions white people have when discussing racism that serve to protect their positions and maintain racial inequality",
                        DatePublished = DateTime.Parse("26/6/2018"),
                        Genre = "Political",
                        Language = "English",
                        Characters = "Nil",
                        DateReceived = DateTime.Parse("15/7/2018"),
                        Location = "Bukit Batok Public Library",
                        Availability = "Available"
                    });
                    context.SaveChanges();
                }
                if (context.Library.Any())
                {
                    return;   // DB has been seeded
                }

                else
                {
                    context.Library.AddRange(
                        new Library
                        {
                            BranchName = "Ang Mo Kio Public Library",
                            BranchLocation = "4300 Ang Mo Kio Avenue 6, 569842",
                            PhoneNumber = "6332 3255"
                        },
                        new Library
                        {
                            BranchName = "Bishan Public Library",
                            BranchLocation = "5 Bishan Pl, #01-01, 579841",
                            PhoneNumber = "6332 3255"
                        },
                        new Library
                        {
                            BranchName = "Lien Ying Chow Library",
                            BranchLocation = "535 Clementi Road",
                            PhoneNumber = "6460 6269"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
