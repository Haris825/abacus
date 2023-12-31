import 'bootstrap/dist/css/bootstrap.css';
import { Link, useParams } from 'react-router-dom';
import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
function EditStudent() {
  const navigate=useNavigate();
  const { id } = useParams();
  const [student, setStudent] = useState({
    firstName: '',
    lastName: '',
    gender: '',
    fatherName: '',
    motherName: '',
    emailId: '',
    phoneNumber1: '',
    phoneNumber2: '',
    age: '',
    houseNo: '',
    streetName: '',
    areaName: '',
    state: '',
    pincode: '',
    nationality: '',
  });
  useEffect(() => {
    fetch(`http://localhost:5049/admin/GetStudent/${id}`)
      .then((response) => response.json())
      .then((data) => {
        if (data.success) {
          setStudent(data.student);
        } else {
          console.error(data.message);
        }
      })
      .catch((error) => {
        console.error('Error:', error);
      });
  }, [id]);

  const handleUpdate = () => {
   const updatedStudent = {
      firstName: student.firstName,
      phoneNumber1: student.phoneNumber1,
      lastName: student.lastName,
      gender: student.gender,
      fatherName: student.fatherName,
      motherName: student.motherName,
      emailId: student.emailId,
      phoneNumber2: student.phoneNumber2,
      age: student.age,
      houseNo: student.houseNo,
      streetName: student.streetName,
      areaName: student.areaName,
      state: student.state,
      pincode: student.pincode,
      nationality: student.nationality,
    };
    const isFormValid = Object.values(updatedStudent).every((value) => value.trim() !== '');
    if (!isFormValid) {
      alert('Please fill in all the fields.');
      return;
    }
  
    fetch(`http://localhost:5049/admin/editStudent/${id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(updatedStudent),
    })
      .then((response) => response.json())
      .then((data) => {
        alert('Student updated successfully:', data);
        navigate('/Students');
      })
      .catch((error) => {
        console.error('Error:', error);
      });
  };
  


  return (
    <>
      <nav className="navbar navbar-expand-lg navbar-light fixed-top" id="userNavbar">
        <button
          className="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className="collapse navbar-collapse" id="navbarSupportedContent">
          <ul className="navbar-nav mx-auto">
            <li className="nav-item active">
              <Link className="nav-link" to="/Academy" id="adminAcademy">
                Academy
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/Course" id="adminCourse">
                Course
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/Students" id="adminStudents">
                Students
              </Link>
            </li>
          </ul>
          <ul className="navbar-nav mr-auto">
            <li className="nav-item">
              <Link to="/" className="nav-link" id="logout">
                Logout
              </Link>
            </li>
          </ul>
        </div>
      </nav>
      <br /><br/>
      <h3 className="text-center mt-4">Edit Student</h3>
      

      <div className="container mt-4">
        <div className="row mb-3">
          <div className="col-md-4">
            <div className="form-group">
              <input type="text" className="form-control" style={{ height: '40px' }} id="editFirstName"
               placeholder="Enter the first name"  value={student.firstName}
               onChange={(e) =>
                setStudent((prev) => ({
                  ...prev,
                  firstName: e.target.value,
                }))
              }/>
            </div>
          </div>
          <div className="col-md-4">
            <div className="form-group">
              <input type="text" className="form-control" style={{ height: '40px' }} id="editLastName"
               placeholder="Enter the last name" value={student.lastName}
               onChange={(e) =>
                setStudent((prev) => ({
                  ...prev,
                  lastName: e.target.value,
                }))
              } />
            </div>
          </div>
          <div className="col-md-4">
            <div className="form-group">
              <select className="form-control" id="editGender" value={student.gender}
             onChange={(e) =>
              setStudent((prev) => ({
                ...prev,
                gender: e.target.value,
              }))
            } >
                <option>Select gender</option>
                <option>Male</option>
                <option>Female</option>
              </select>
            </div>
          </div>
        </div>
        <div className="row mb-3">
          <div className="col-md-4">
            <div className="form-group">
              <input type="text" className="form-control" style={{ height: '40px' }} id="editFatherName" 
              placeholder="Enter father's name" value={student.fatherName}
              onChange={(e) =>
                setStudent((prev) => ({
                  ...prev,
                  fatherName: e.target.value,
                }))
              } />
            </div>
          </div>
          <div className="col-md-4">
            <div className="form-group">
            
              <input type="text" className="form-control" style={{ height: '40px' }} id="editPhoneNumber1" 
              placeholder="Enter phone number"
              value={student.phoneNumber1} 
              onChange={(e) =>
                setStudent((prev) => ({
                  ...prev,
                  phoneNumber1: e.target.value,
                }))
              }/>
            </div>
          </div>
          <div className="col-md-4">
            <div className="form-group">
             
              <input type="text" className="form-control" style={{ height: '40px' }} id="editPhoneNumber2" 
              placeholder="Enter alternative phone number"  value={student.phoneNumber2}
              onChange={(e) =>
                setStudent((prev) => ({
                  ...prev,
                  phoneNumber2: e.target.value,
                }))
              }/>
            </div>
          </div>
        </div>
        <div className="row mb-3">
        <div className="col-md-4">
            <div className="form-group">
              <input type="text" className="form-control" style={{ height: '40px' }} id="editMotherName" 
              placeholder="Enter mother's name" value={student.motherName}
              onChange={(e) =>
                setStudent((prev) => ({
                  ...prev,
                  motherName: e.target.value,
                }))
              } />
            </div>
          </div>
          <div className="col-md-4">
            <div className="form-group">
              <input type="text" className="form-control" style={{ height: '40px' }} id="editEmailId" 
              placeholder="Enter email id" value={student.emailId}
              onChange={(e) =>
                setStudent((prev) => ({
                  ...prev,
                  emailId: e.target.value,
                }))
              } />
            </div>
          </div>
          <div className="col-md-4">
            <div className="form-group">
              <input type="text" className="form-control" style={{ height: '40px' }} id="editAge" 
              placeholder="Enter age" value={student.age}
              onChange={(e) =>
                setStudent((prev) => ({
                  ...prev,
                  age: e.target.value,
                }))
              } />
            </div>
          </div>
        </div>
        <div className="row mb-3">
          <div className="col-md-8">
            <div className="card border-primary">
              <div className="card-header">Address Information</div>
              <div className="card-body">
                <div className="row mb-3">
                  <div className="col-md-6">
                    <div className="form-group">
                      <label htmlFor="houseNo">House No</label>
                      <input type="text" className="form-control" style={{ height: '40px' }} id="editHouseNo" 
                      value={student.houseNo}
                      onChange={(e) =>
                setStudent((prev) => ({
                  ...prev,
                  houseNo: e.target.value,
                }))
              } />
                    </div>
                  </div>
                  <div className="col-md-6">
                    <div className="form-group">
                      <label htmlFor="streetName">Street</label>
                      <input type="text" className="form-control" style={{ height: '40px' }}
                       id="editStreetName" value={student.streetName}
                       onChange={(e) =>
                        setStudent((prev) => ({
                          ...prev,
                          streetName: e.target.value,
                        }))
                      } />
                    </div>
                  </div>
                </div>
                <div className="row mb-3">
                  <div className="col-md-6">
                    <div className="form-group">
                      <label htmlFor="areaName">Area</label>
                      <input type="text" className="form-control" style={{ height: '40px' }}
                       id="editAreaName"  value={student.areaName}
                       onChange={(e) =>
                        setStudent((prev) => ({
                          ...prev,
                          areaName: e.target.value,
                        }))
                      }/>
                    </div>
                  </div>
                  <div className="col-md-6">
                    <div className="form-group">
                      <label htmlFor="state">State</label>
                      <input type="text" className="form-control" style={{ height: '40px' }}
                       id="editState" value={student.state}
                       onChange={(e) =>
                        setStudent((prev) => ({
                          ...prev,
                          state: e.target.value,
                        }))
                      } />
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6">
                    <div className="form-group">
                      <label htmlFor="pincode">Pincode</label>
                      <input type="text" className="form-control" style={{ height: '40px' }}
                       id="editPincode" value={student.pincode}
                       onChange={(e) =>
                        setStudent((prev) => ({
                          ...prev,
                          pincode: e.target.value,
                        }))
                      } />
                    </div>
                  </div>
                  <div className="col-md-6">
                    <div className="form-group">
                      <label htmlFor="nationality">Nationality</label>
                      <input type="text" className="form-control" style={{ height: '40px' }} 
                      id="editNationality" value={student.nationality}
                      onChange={(e) =>
                        setStudent((prev) => ({
                          ...prev,
                          nationality: e.target.value,
                        }))
                      }/>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="row">
          <div className="col-md-12">
            <div className="edit-student-button">
            <button className="btn btn-primary" id="editStudent" onClick={handleUpdate}>
  Update Student
</button>

            </div>
            <style>
              {`
               .body {
                background-color: #f8f4f7;
              }
            
              #userNavbar {
                background-color: rgb(43, 110, 57);
              }
            
              .navbar-brand {
                font-size: 40px;
                color: white;
              }
              
              #adminAcademy {
                font-size: 20px;
                font-weight:light;
                color: white;
              }
            
              #adminCourse {
                font-size: 20px;
                color: white;
              }
              #adminStudents {
                font-size: 25px;
                color: white;
              }
              h3{
                color:white;
              }
            
              #logout {
                font-size: 20px;
                color: white;
              }
            
              .edit-student-button {
                position: fixed;
                bottom: 50px;
                right: 125px;
              }
              
              @media (max-width: 768px) {
                .edit-student-button {
                  position: static;
                  margin-top: 20px;
                  text-align: center;
                }
              }
            
              body {
                background: #797979;
              }
            
              /* Adjust the form field alignment */
              .form-group:nth-child(2),
              .form-group:nth-child(3) {
                margin-bottom: 0;
              }
              `}
            </style>
          </div>
        </div>
      </div>
      
    </>
  );
}

export default EditStudent;
