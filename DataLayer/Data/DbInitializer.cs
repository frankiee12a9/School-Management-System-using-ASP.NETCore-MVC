using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Data
{
	public static class DbInitializer
	{
		public static void InitializeDb(ApplicationDbContext db)
		{
			db.Database.EnsureCreated();

			if (db.Departments.Any())
			{
				return;
			}

			var departments = new Department[]
			{
				new Department { DepartmentID = 2201, DepartmentName="Computer Science Dept"},
				new Department { DepartmentID = 2202, DepartmentName= "Mathematics Dept"},
				new Department { DepartmentID = 2203, DepartmentName= "Language and Trade Dept"}
			};

			db.Departments.AddRange(departments);

		/*	var courses = new Course[]
			{
				new Course
				{
					CourseId = 1101,  CourseName = "Data Structure", CourseType="Required",
					CourseCredit=3, ClassPlace1="Sebit Building", ClassTime1="Monday 9 A.M", ClassPlace2="Hoado building", ClassTime2="Monday 11 A.M",
					Week1="Learn 1", Week2="Learn 2", Week3="Learn 3", Week4="Learn 4", Week5="Learn 5", Week6="Learn 6", Week7="Learn 7",
					Week8="Learn 8", Week9="Learn 9", Week10="Learn 10"
				}  , 
				new Course
				{
					CourseId = 1102,  CourseName = "Discrete Math", CourseType="Required",
					CourseCredit=3, ClassPlace1="Sebit Building", ClassTime1="Wednesday 9 A.M", ClassPlace2="Bima building", ClassTime2="Monday 1 P.M",
					Week1="Learn 1", Week2="Learn 2", Week3="Learn 3", Week4="Learn 4", Week5="Learn 5", Week6="Learn 6", Week7="Learn 7",
					Week8="Learn 8", Week9="Learn 9", Week10="Learn 10"
				},
				new Course
				{
					CourseId = 1103,  CourseName = "Algorithm", CourseType="Required",
					CourseCredit=3, ClassPlace1="Sebit Building", ClassTime1="Monday 3 P.M", ClassPlace2="Sebit building", ClassTime2="Tuesday 11 A.M",
					Week1="Learn 1", Week2="Learn 2", Week3="Learn 3", Week4="Learn 4", Week5="Learn 5", Week6="Learn 6", Week7="Learn 7",
					Week8="Learn 8", Week9="Learn 9", Week10="Learn 10"
				},
				new Course
				{
					CourseId = 1104,  CourseName = "Database", CourseType="Required",
					CourseCredit=3, ClassPlace1="Sebit Building", ClassTime1="Friday 9 A.M", ClassPlace2="Sebit building", ClassTime2="Monday 11 A.M",
					Week1="Learn 1", Week2="Learn 2", Week3="Learn 3", Week4="Learn 4", Week5="Learn 5", Week6="Learn 6", Week7="Learn 7",
					Week8="Learn 8", Week9="Learn 9", Week10="Learn 10"
				},
				new Course
				{
					CourseId = 1105,  CourseName = "English Conversation", CourseType="Elective",
					CourseCredit=2, ClassPlace1="Sebit Building", ClassTime1="Thursday 5 P.M", ClassPlace2="Hannul building", ClassTime2="Wednesday 3 P.M",
					Week1="Learn 1", Week2="Learn 2", Week3="Learn 3", Week4="Learn 4", Week5="Learn 5", Week6="Learn 6", Week7="Learn 7",
					Week8="Learn 8", Week9="Learn 9", Week10="Learn 10"
				}
			};
			
			// add courses to db 
			db.Courses.AddRange(courses);

			var courseAssignments = new CourseAssignment[]
			{
				new CourseAssignment { CourseId = 1101, LecturerId="2246b434-49f9-4d18-b6b4-a6dba5fb7f0c"},
				new CourseAssignment { CourseId = 1102, LecturerId="a6a92a9e-a05b-42af-a522-b6c5dd9cea33"},
				new CourseAssignment { CourseId = 1103, LecturerId="b74b5e07-9072-4fe7-8548-05662e431164"},
				new CourseAssignment { CourseId = 1104, LecturerId="e2170fc9-8c84-4c67-b82e-6386b680a8e1"},
				new CourseAssignment { CourseId = 1105, LecturerId="fa612fc0-5fd0-48d9-906f-419233bfd57b"}
			};

			db.CourseAssigments.AddRange(courseAssignments);

			var enrollements = new Enrollment[]
			{
				new Enrollment { CourseId = 1101, StudentId="d5f7ca0d-741d-40d8-98ae-94750962def7"},
				new Enrollment { CourseId = 1102, StudentId="d5f7ca0d-741d-40d8-98ae-94750962def7"},
				new Enrollment { CourseId = 1103, StudentId="d5f7ca0d-741d-40d8-98ae-94750962def7"},
				new Enrollment { CourseId = 1104, StudentId="d5f7ca0d-741d-40d8-98ae-94750962def7"},
				new Enrollment { CourseId = 1105, StudentId="d5f7ca0d-741d-40d8-98ae-94750962def7"}
			};

			db.CourseEnrollments.AddRange(enrollements);

		*/



			// save changes 
			db.SaveChanges();
		}
	}
}
