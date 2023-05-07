using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dormitory.DAL;
using Dormitory.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace Dormitory.BLL
{
    internal class AplicationManagment
    {
        internal static void AddAplication()
        {
            using var context = new DormitoryContext();
            // to do show all announcement
            

            var existingAnnouncements = context.Announcemnt
         .Include(x => x.Room)
         .Where(x => x.IsActive == true)
         .ToList();
            // Show all announcements
            Console.WriteLine("List of announcements: ");
            foreach (var announcement in existingAnnouncements)
            {
                Console.WriteLine($"Id: {announcement.Id}, Title: {announcement.Title}, " +
                    $"Description: {announcement.Description}, Room: {announcement.Room.Name}");
            }
            // Get announcement Id
            Console.WriteLine("Enter announcement Id:");
            _ = int.TryParse(Console.ReadLine(), out var announcementId);
            // Check if announcement exists
            var announcementExists = existingAnnouncements.Any(announcement => announcement.Id == announcementId);
            if (!announcementExists)
            {
                Console.WriteLine($"Announcement {announcementId}, does not exist!");
                _ = Console.ReadLine();
                return;
            }
            // Get list of students
            var existingStudents = context.Students.ToList();
            // Show all students
            Console.WriteLine("List of students: ");
            foreach (var student in existingStudents)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}");
            }
            // Get student Id
            Console.WriteLine("Enter student Id:");
            _ = int.TryParse(Console.ReadLine(), out var studentId);
            // Check if student exists
            var studentExists = existingStudents.Any(student => student.Id == studentId);
            if (!studentExists)
            {
                Console.WriteLine($"Student {studentId}, does not exist!");
                _ = Console.ReadLine();
                return;
            }
            // Create application
            var application = new Application
            {
                AnnouncementId = announcementId,
                StudentId = studentId,
                ApplicationDate = DateTime.Now,
                IsActive = true
            };
            // Add application to database
            var created = context.Applications.Add(application);
            Console.WriteLine($"Application {created.Entity.Id} is added.");
            // Save changes
            _ = context.SaveChanges();
        }

        public static void ApproveApplication()
        {
            //  Implement this method
            using var context = new DormitoryContext();
            // Get all active applications

            var existingApplications = context.Applications
                .Include(x => x.Student)
                .Include(x => x.Announcement)
                .ThenInclude(x=>x.Room)
                .Where(x => x.IsActive == true)
                .ToList();
            //  Show all applications to user
            Console.WriteLine("List of active aplication");
            foreach(var application in existingApplications)
            {
                Console.WriteLine($"ApplicationID: {application.Id}, Announcemnt: {application.Announcement.Id}"+
                    $"studentID: {application.StudentId}, sudentName: {application.Student.Name}, RoomID:{application.Announcement.RoomId},RoomName:{application.Announcement.Room.Name}");
            }

            //  Get application Id
            Console.WriteLine("Enter aplication Id:");
            _ = int.TryParse(Console.ReadLine(), out var applicationId);
            // Check if application exists
            var applicationExists = existingApplications.FirstOrDefault(application => application.Id == applicationId);
            if (applicationExists==null)
            {
                Console.WriteLine($"Aplication {applicationId}, does not exist!");
                _ = Console.ReadLine();
                return;
            }

            // TODO: Get student id from application

            var studentId=AplicationManagment.StudentId;


            // TODO: Get room id from application
            var roomId=AplicationManagment.Announcement.RoomId;

            // TODO: Add to RoomStudent
            _=context.RoomStudents.Add(new RoomStudent
                {
                RoomId=roomId,
                StudentId=studentId,
                StartDate=DateTime.Now
            });

            // TO DO: Set other application, for this room, to inactive
            // TOD: Set this announcement to inactive

            // TODO: Save changes
        }

    }
    }

