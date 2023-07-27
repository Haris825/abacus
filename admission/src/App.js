import React from 'react';
import { Routes, Route } from 'react-router-dom';
import AdminAcademy from './components/Admin/Academy/AdminAcademy';
import EditAcademy from './components/Admin/Academy/EditAcademy';
import AddAcademy from './components/Admin/Academy/AddAcademy';
import AdminCourse from './components/Admin/Course/AdminCourse';
import AddCourse from './components/Admin/Course/AddCourse';
import EditCourse from './components/Admin/Course/EditCourse';
import AdminStudent from './components/Admin/Students/AdminStudent';
import AddStudent from './components/Admin/Students/AddStudent';
import EditStudent from './components/Admin/Students/EditStudent';


function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/Editinstitute/:id" element={<EditAcademy />} />
        <Route path="/addAcademy" element={<AddAcademy />} />
        <Route path="/Course" element={<AdminCourse />} />
        <Route path="/" element={<AdminAcademy />} />
        <Route path="/addCourse" element={<AddCourse/>} />
        <Route path="/editCourse/:id" element={<EditCourse />} />
        <Route path="/editStudent/:id" element={<EditStudent/>}/>
        <Route path="/academy" element={<AdminAcademy/>} />
        <Route path="/Students" element={<AdminStudent />} />
        <Route path="/addStudent" element={<AddStudent />} />
      </Routes>
      
    </div>
  );
}

export default App;
