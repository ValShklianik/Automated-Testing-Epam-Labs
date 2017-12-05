// 1 university
// 2 faculties: MMF and FRM
// 8 groups: 4 groups in MMF, 4 groups in FPM
// 10 students in every group
// 3 subjects: math, programing, testing
// 7 marks by every subject

using System;
using System.Collections.Generic;
using UniversitySystemLogic;
using System.Threading;

namespace UniversitySystemConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var BSU = new Universiry("BSU");

            var MMF = new Faculty("MMF");
            var FPM = new Faculty("FPM");

            BSU.AddFaculty(MMF);
            BSU.AddFaculty(FPM);


            for (var i = 1; i < 5; i++)
            {
                var group = new Group($"group_{i}_MMF");
                MMF.AddGroups(group);
                for (var j = 1; j <= 10; j++)
                {
                    var student = new Student($"student_{j}_MMF");
                    group.AddStudent(student);


                    var listMarks = new List<int>();
                    for (var k = 0; k < 7; k++)
                    {
                        var mark = new Random(i*20);
                        listMarks.Add((mark.Next(4, 9) + i*k/j%10 -1));
                    }
                    student.AddMark("math", listMarks);


                    var listMarks1 = new List<int>();
                    for (var s = 0; s < 7; s++)
                    {
                        var mark = new Random(i*20);
                        listMarks1.Add(mark.Next(4, 9) + j+s - 4 -1);
                    }
                    student.AddMark("programming", listMarks1);

                    var listMarks2 = new List<int>();
                    for (var r = 0; r < 7; r++)
                    {
                        var mark = new Random(i*14);
                        listMarks2.Add(mark.Next(4, 9) + i/4 + j/10 - 1);
                    }
                    student.AddMark("testing", listMarks2);


                }
            }

            for (var i = 1; i < 5; i++)
            {
                var group = new Group($"group_{i}_FPM");
                FPM.AddGroups(group);
                for (var j = 1; j <= 10; j++)
                {
                    var student = new Student($"student_{j}_FPM");
                    group.AddStudent(student);

                    var listMarks = new List<int>();
                    for (var k = 0; k < 7; k++)
                    {
                        var mark = new Random();
                        listMarks.Add(mark.Next(4, 9) +i%10 -2);
                    }
                    student.AddMark("math", listMarks);

                    listMarks = new List<int>();
                    for (var k = 0; k < 7; k++)
                    {
                        var mark = new Random();
                        listMarks.Add(mark.Next(4, 9)+j/5 -1);
                    }
                    student.AddMark("programming", listMarks);

                    listMarks = new List<int>();
                    for (var k = 0; k < 7; k++)
                    {
                        var mark = new Random();
                        listMarks.Add(mark.Next(4, 9) + i/2 + j%(k+1) - 2);
                    }
                    student.AddMark("testing", listMarks);
                }
            }

            Console.WriteLine($"avarage of BSU: {BSU.GetEverage()}");
            Console.WriteLine();
            Console.WriteLine($"avarage of MMf: {MMF.GetEverage()}");
            Console.WriteLine($"avarage of FPM: {FPM.GetEverage()}");
            Console.WriteLine();
            Console.WriteLine($"average of group_1_mmf : {MMF.Groups.Find(group => group.groupNumber == "group_1_MMF").GetEverage()}");
            Console.WriteLine($"average of group_2_mmf : {MMF.Groups.Find(group => group.groupNumber == "group_2_MMF").GetEverage()}");
            Console.WriteLine($"average of group_3_mmf : {MMF.Groups.Find(group => group.groupNumber == "group_3_MMF").GetEverage()}");
            Console.WriteLine($"average of group_4_mmf : {MMF.Groups.Find(group => group.groupNumber == "group_4_MMF").GetEverage()}");
            Console.WriteLine();
            Console.WriteLine($"average of group_1_fpm : {FPM.Groups.Find(group => group.groupNumber == "group_1_FPM").GetEverage()}");
            Console.WriteLine($"average of group_2_fpm : {FPM.Groups.Find(group => group.groupNumber == "group_2_FPM").GetEverage()}");
            Console.WriteLine($"average of group_3_fpm : {FPM.Groups.Find(group => group.groupNumber == "group_3_FPM").GetEverage()}");
            Console.WriteLine($"average of group_4_fpm : {FPM.Groups.Find(group => group.groupNumber == "group_4_FPM").GetEverage()}");
            Console.WriteLine();
            Console.WriteLine($"average of student_1_mmf group_1 : {MMF.Groups.Find(group => group.groupNumber == "group_1_MMF").Students.Find(name => name.studentName== "student_1_MMF").GetEverage()}");
            Console.WriteLine($"average of student_2_mmf group_1: {MMF.Groups.Find(group => group.groupNumber == "group_1_MMF").Students.Find(name => name.studentName == "student_2_MMF").GetEverage()}");
            Console.WriteLine($"average of student_3_mmf group_2: {MMF.Groups.Find(group => group.groupNumber == "group_2_MMF").Students.Find(name => name.studentName == "student_3_MMF").GetEverage()}");
            Console.WriteLine($"average of student_4_mmf group_2: {MMF.Groups.Find(group => group.groupNumber == "group_2_MMF").Students.Find(name => name.studentName == "student_4_MMF").GetEverage()}");
            Console.WriteLine($"average of student_5_mmf group_2: {MMF.Groups.Find(group => group.groupNumber == "group_2_MMF").Students.Find(name => name.studentName == "student_5_MMF").GetEverage()}");
            Console.WriteLine($"average of student_6_mmf group_3: {MMF.Groups.Find(group => group.groupNumber == "group_3_MMF").Students.Find(name => name.studentName == "student_6_MMF").GetEverage()}");
            Console.WriteLine($"average of student_7_mmf group_3: {MMF.Groups.Find(group => group.groupNumber == "group_3_MMF").Students.Find(name => name.studentName == "student_7_MMF").GetEverage()}");
            Console.WriteLine($"average of student_8_mmf group_4: {MMF.Groups.Find(group => group.groupNumber == "group_4_MMF").Students.Find(name => name.studentName == "student_8_MMF").GetEverage()}");
            Console.WriteLine($"average of student_9_mmf group_4: {MMF.Groups.Find(group => group.groupNumber == "group_4_MMF").Students.Find(name => name.studentName == "student_9_MMF").GetEverage()}");
            Console.WriteLine($"average of student_10_mmf group_4: {MMF.Groups.Find(group => group.groupNumber == "group_4_MMF").Students.Find(name => name.studentName == "student_10_MMF").GetEverage()}");
            Console.WriteLine();
            Console.WriteLine($"average of student_1_fpm group_1 : {FPM.Groups.Find(group => group.groupNumber == "group_1_FPM").Students.Find(name => name.studentName == "student_1_FPM").GetEverage()}");
            Console.WriteLine($"average of student_2_fpm group_1: {FPM.Groups.Find(group => group.groupNumber == "group_1_FPM").Students.Find(name => name.studentName == "student_2_FPM").GetEverage()}");
            Console.WriteLine($"average of student_3_fpm group_2: {FPM.Groups.Find(group => group.groupNumber == "group_2_FPM").Students.Find(name => name.studentName == "student_3_FPM").GetEverage()}");
            Console.WriteLine($"average of student_4_fpm group_2: {FPM.Groups.Find(group => group.groupNumber == "group_2_FPM").Students.Find(name => name.studentName == "student_4_FPM").GetEverage()}");
            Console.WriteLine($"average of student_5_fpm group_2: {FPM.Groups.Find(group => group.groupNumber == "group_2_FPM").Students.Find(name => name.studentName == "student_5_FPM").GetEverage()}");
            Console.WriteLine($"average of student_6_fpm group_3: {FPM.Groups.Find(group => group.groupNumber == "group_3_FPM").Students.Find(name => name.studentName == "student_6_FPM").GetEverage()}");
            Console.WriteLine($"average of student_7_fpm group_3: {FPM.Groups.Find(group => group.groupNumber == "group_3_FPM").Students.Find(name => name.studentName == "student_7_FPM").GetEverage()}");
            Console.WriteLine($"average of student_8_fpm group_4: {FPM.Groups.Find(group => group.groupNumber == "group_4_FPM").Students.Find(name => name.studentName == "student_8_FPM").GetEverage()}");
            Console.WriteLine($"average of student_9_fpm group_4: {FPM.Groups.Find(group => group.groupNumber == "group_4_FPM").Students.Find(name => name.studentName == "student_9_FPM").GetEverage()}");
            Console.WriteLine($"average of student_10_fpm group_4: {FPM.Groups.Find(group => group.groupNumber == "group_4_FPM").Students.Find(name => name.studentName == "student_10_FPM").GetEverage()}");
            Console.WriteLine();
            Console.WriteLine($"average of student_1_mmf group_1 by math: {MMF.Groups.Find(group => group.groupNumber == "group_1_MMF").Students.Find(name => name.studentName == "student_1_MMF").GetEverage("math")}");
            Console.WriteLine($"average of student_2_mmf group_1 by programmming: {MMF.Groups.Find(group => group.groupNumber == "group_1_MMF").Students.Find(name => name.studentName == "student_2_MMF").GetEverage("programming")}");
            Console.WriteLine($"average of student_3_mmf group_2 by testing: {MMF.Groups.Find(group => group.groupNumber == "group_2_MMF").Students.Find(name => name.studentName == "student_3_MMF").GetEverage("testing")}");
            Console.WriteLine($"average of student_4_mmf group_2 bu math: {MMF.Groups.Find(group => group.groupNumber == "group_2_MMF").Students.Find(name => name.studentName == "student_4_MMF").GetEverage("math")}");
            Console.WriteLine($"average of student_5_mmf group_2 by programming: {MMF.Groups.Find(group => group.groupNumber == "group_2_MMF").Students.Find(name => name.studentName == "student_5_MMF").GetEverage("programming")}");
            Console.WriteLine($"average of student_6_mmf group_3 by testing: {MMF.Groups.Find(group => group.groupNumber == "group_3_MMF").Students.Find(name => name.studentName == "student_6_MMF").GetEverage("testing")}");
            Console.WriteLine($"average of student_7_mmf group_3 by math: {MMF.Groups.Find(group => group.groupNumber == "group_3_MMF").Students.Find(name => name.studentName == "student_7_MMF").GetEverage("math")}");
            Console.WriteLine($"average of student_8_mmf group_4 by programming: {MMF.Groups.Find(group => group.groupNumber == "group_4_MMF").Students.Find(name => name.studentName == "student_8_MMF").GetEverage("programming")}");
            Console.WriteLine($"average of student_9_mmf group_4 by testing: {MMF.Groups.Find(group => group.groupNumber == "group_4_MMF").Students.Find(name => name.studentName == "student_9_MMF").GetEverage("testing")}");
            Console.WriteLine($"average of student_10_mmf group_4 by testing: {MMF.Groups.Find(group => group.groupNumber == "group_4_MMF").Students.Find(name => name.studentName == "student_10_MMF").GetEverage("testing")}");
            Console.WriteLine();

        }
    }
}
