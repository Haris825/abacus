using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using dept.Models;
using Admin.Models;
using Students.Models;
namespace Admin.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdminController : ControllerBase
    {
        private readonly string _connectionString;

        public AdminController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpPost]
        public IActionResult addCourse([FromBody] Course course)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO addCourse (course_name, course_duration, course_enrolled, course_timing, course_description) VALUES (@courseName, @courseDuration, @courseEnrolled, @courseTiming, @courseDescription)", connection);

                    command.Parameters.AddWithValue("@courseName", course.courseName);
                    command.Parameters.AddWithValue("@courseDuration", course.courseDuration);
                    command.Parameters.AddWithValue("@courseEnrolled", course.courseEnrolled);
                    command.Parameters.AddWithValue("@courseTiming", course.courseTiming);
                    command.Parameters.AddWithValue("@courseDescription", course.courseDescription);

                    command.ExecuteNonQuery();
                }

                return Ok(new { success = true, message = "Course added" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
          [HttpPut("{id}")]
    public IActionResult editCourse(int id, [FromBody] Course course)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE addCourse SET course_name = @courseName, course_duration = @courseDuration, course_enrolled= @courseEnrolled, course_timing = @courseTiming, course_description = @courseDescription WHERE id = @Id", connection);

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@courseName", course.courseName);
                command.Parameters.AddWithValue("@courseDuration", course.courseDuration);
                command.Parameters.AddWithValue("@courseEnrolled", course.courseEnrolled);
                command.Parameters.AddWithValue("@courseTiming", course.courseTiming);
                command.Parameters.AddWithValue("@courseDescription", course.courseDescription);


                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    return NotFound("Course edited");
                }
            }

            return Ok(new { success = true, message = "Course updated successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
      [HttpGet("{id}")]
    public IActionResult GetCourse(int id)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM addCourse WHERE id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Course course = new Course
                    {
                        Id = (int)reader["id"],
                        courseName = (string)reader["course_name"],
                        courseDuration = (string)reader["course_duration"],
                        courseEnrolled = (string)reader["course_enrolled"],
                        courseTiming = (string)reader["course_timing"],
                        courseDescription = (string)reader["course_description"]
                    };

                    return Ok(new { success = true, course });
                }

                return NotFound("Course not found");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
     [HttpGet]
    public IActionResult viewCourse()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM addCourse", connection);
                SqlDataReader reader = command.ExecuteReader();

                List<Course> courses = new List<Course>();

                while (reader.Read())
                {
                    Course course = new Course
                    {
                        Id = (int)reader["id"],
                        courseName = (string)reader["course_name"],
                        courseDuration = (string)reader["course_duration"],
                        courseEnrolled = (string)reader["course_enrolled"],
                        courseTiming = (string)reader["course_timing"],
                        courseDescription = (string)reader["course_description"]
                    };

                    courses.Add(course);
                }

                return Ok(new { success = true, courses });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult deleteCourse(int id)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM addCourse WHERE id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    return NotFound("Course not found");
                }
            }

            return Ok(new { success = true, message = "Course deleted" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

        [HttpPost]
        public IActionResult addInstitute([FromBody] Institute institute)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO addAcademy (academy_name, academy_number, academy_image_url, academy_email, academy_location, academy_description) VALUES (@academyName, @contactNumber, @imageUrl, @emailId, @academyLocation, @academyDescription)", connection);

                    command.Parameters.AddWithValue("@academyName", institute.academyName);
                    command.Parameters.AddWithValue("@contactNumber", institute.contactNumber);
                    command.Parameters.AddWithValue("@imageUrl", institute.imageUrl);
                    command.Parameters.AddWithValue("@emailId", institute.emailId);
                    command.Parameters.AddWithValue("@academyLocation", institute.academyLocation);
                    command.Parameters.AddWithValue("@academyDescription", institute.academyDescription);

                    command.ExecuteNonQuery();
                }

                return Ok(new { success = true, message = "Institute added" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

     

        [HttpPut("{id}")]
        public IActionResult editInstitute(int id, [FromBody] Institute institute)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("UPDATE addAcademy SET academy_name = @academyName, academy_number = @contactNumber, academy_image_url = @imageUrl, academy_email = @emailId, academy_location = @academyLocation, academy_description = @academyDescription WHERE id = @Id", connection);

                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@academyName", institute.academyName);
                    command.Parameters.AddWithValue("@contactNumber", institute.contactNumber);
                    command.Parameters.AddWithValue("@imageUrl", institute.imageUrl);
                    command.Parameters.AddWithValue("@emailId", institute.emailId);
                    command.Parameters.AddWithValue("@academyLocation", institute.academyLocation);
                    command.Parameters.AddWithValue("@academyDescription", institute.academyDescription);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        return NotFound("Institute not found");
                    }
                }

                return Ok(new { success = true, message = "Institute edited" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetInstitute(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM addAcademy WHERE id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Institute institute = new Institute
                        {
                            Id = (int)reader["id"],
                            academyName = (string)reader["academy_name"],
                            contactNumber = (string)reader["academy_number"],
                            imageUrl = (string)reader["academy_image_url"],
                            emailId = (string)reader["academy_email"],
                            academyLocation = (string)reader["academy_location"],
                            academyDescription = (string)reader["academy_description"]
                        };

                        return Ok(new { success = true, institute });
                    }

                    return NotFound("Institute not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult viewInstitute()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM addAcademy", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    List<Institute> institutes = new List<Institute>();

                    while (reader.Read())
                    {
                        Institute institute = new Institute
                        {
                            Id = (int)reader["id"],
                            academyName = (string)reader["academy_name"],
                            contactNumber = (string)reader["academy_number"],
                            imageUrl = (string)reader["academy_image_url"],
                            emailId = (string)reader["academy_email"],
                            academyLocation = (string)reader["academy_location"],
                            academyDescription = (string)reader["academy_description"]
                        };

                        institutes.Add(institute);
                    }

                    return Ok(new { success = true, institutes });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteInstitute(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM addAcademy WHERE id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        return NotFound("Institute not found");
                    }
                }

                return Ok(new { success = true, message = "Institute deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

       
  [HttpPost]
        public IActionResult addStudent([FromBody] Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO addStudent (firstName, courseEnrolled, phoneNumber1, lastName, gender, fatherName, MotherName, emailId,phoneNumber2, age, houseNo, streetName, areaName, state, pincode, nationality) VALUES (@firstName, @courseEnrolled, @phoneNumber1, @lastName, @gender, @fatherName, @MotherName, @emailId,@phoneNumber2, @age, @houseNo, @streetName, @areaName, @state, @pincode, @nationality)", connection);

                    command.Parameters.AddWithValue("@firstName", student.firstName);
                    command.Parameters.AddWithValue("@courseEnrolled", student.courseEnrolled);
                    command.Parameters.AddWithValue("@phoneNumber1", student.phoneNumber1);
                    command.Parameters.AddWithValue("@lastName", student.lastName);
                    command.Parameters.AddWithValue("@gender", student.gender);
                    command.Parameters.AddWithValue("@fatherName", student.fatherName);
                    command.Parameters.AddWithValue("@MotherName", student.MotherName);
                    command.Parameters.AddWithValue("@emailId", student.emailId);
                     command.Parameters.AddWithValue("@phoneNumber2", student.phoneNumber2);
                    command.Parameters.AddWithValue("@age", student.age);
                    command.Parameters.AddWithValue("@houseNo", student.houseNo);
                    command.Parameters.AddWithValue("@streetName", student.streetName);
                    command.Parameters.AddWithValue("@areaName", student.areaName);
                    command.Parameters.AddWithValue("@state", student.state);
                    command.Parameters.AddWithValue("@pincode", student.pincode);
                    command.Parameters.AddWithValue("@nationality", student.nationality);

                    command.ExecuteNonQuery();
                }

                return Ok(new { success = true, message = "Student added" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult editStudent(int id, [FromBody] Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("UPDATE addStudent SET firstName = @firstName, courseEnrolled = @courseEnrolled, phoneNumber1 = @phoneNumber1, lastName = @lastName, gender = @gender, fatherName = @fatherName, MotherName = @MotherName, emailId = @emailId,phoneNumber2=@phoneNumber2, age = @age, houseNo = @houseNo, streetName = @streetName, areaName = @areaName, state = @state, pincode = @pincode, nationality = @nationality WHERE id = @Id", connection);

                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@firstName", student.firstName);
                    command.Parameters.AddWithValue("@courseEnrolled", student.courseEnrolled);
                    command.Parameters.AddWithValue("@phoneNumber1", student.phoneNumber1);
                    command.Parameters.AddWithValue("@lastName", student.lastName);
                    command.Parameters.AddWithValue("@gender", student.gender);
                    command.Parameters.AddWithValue("@fatherName", student.fatherName);
                    command.Parameters.AddWithValue("@MotherName", student.MotherName);
                    command.Parameters.AddWithValue("@emailId", student.emailId);
                    command.Parameters.AddWithValue("@phoneNumber2", student.phoneNumber2);
                    command.Parameters.AddWithValue("@age", student.age);
                    command.Parameters.AddWithValue("@houseNo", student.houseNo);
                    command.Parameters.AddWithValue("@streetName", student.streetName);
                    command.Parameters.AddWithValue("@areaName", student.areaName);
                    command.Parameters.AddWithValue("@state", student.state);
                    command.Parameters.AddWithValue("@pincode", student.pincode);
                    command.Parameters.AddWithValue("@nationality", student.nationality);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        return NotFound("Student not found");
                    }
                }

                return Ok(new { success = true, message = "Student details edited" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM addStudent WHERE id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = (int)reader["id"],
                            firstName = (string)reader["firstName"],
                            courseEnrolled = (string)reader["courseEnrolled"],
                            phoneNumber1 = (string)reader["phoneNumber1"],
                            lastName = (string)reader["lastName"],
                            gender = (string)reader["gender"],
                            fatherName = (string)reader["fatherName"],
                            MotherName = (string)reader["MotherName"],
                            emailId = (string)reader["emailId"],
                             phoneNumber2 = (string)reader["phoneNumber2"],
                            age = (string)reader["age"],
                            houseNo = (string)reader["houseNo"],
                            streetName = (string)reader["streetName"],
                            areaName = (string)reader["areaName"],
                            state = (string)reader["state"],
                            pincode = (string)reader["pincode"],
                            nationality = (string)reader["nationality"]
                        };

                        return Ok(new { success = true, student });
                    }

                    return NotFound("Student not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult viewStudent()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM addStudent", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    List<Student> students = new List<Student>();

                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = (int)reader["id"],
                            firstName = (string)reader["firstName"],
                            courseEnrolled = (string)reader["courseEnrolled"],
                            phoneNumber1 = (string)reader["phoneNumber1"],
                            lastName = (string)reader["lastName"],
                            gender = (string)reader["gender"],
                            fatherName = (string)reader["fatherName"],
                            MotherName = (string)reader["MotherName"],
                            emailId = (string)reader["emailId"],
                            phoneNumber2 = (string)reader["phoneNumber2"],
                            age = (string)reader["age"],
                            houseNo = (string)reader["houseNo"],
                            streetName = (string)reader["streetName"],
                            areaName = (string)reader["areaName"],
                            state = (string)reader["state"],
                            pincode = (string)reader["pincode"],
                            nationality = (string)reader["nationality"]
                        };

                        students.Add(student);
                    }

                    return Ok(new { success = true, students });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult deleteStudent(int id)
        {
            try
            {
                // Code to delete a student from the database
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM addStudent WHERE id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        return NotFound("Student not found");
                    }
                }

                return Ok(new { success = true, message = "Student details deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}