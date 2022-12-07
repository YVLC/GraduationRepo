import Register from './components/Registration/Register';
import Login from './components/Registration/Login';
import Home from './components/Pages/Home'
import About from './components/Pages/About'
import Profile from './components/Pages/Profile'
import Contact from './components/Pages/Contact'
import { Routes, Route } from 'react-router-dom';
import RequireAuth from './components/RequireAuth';
import NavBar from './components/NavBar';
import Missing from './components/Pages/Missing'
import Unauthorized from './components/Pages/Unauthorized';
function App() {

  return (
    <main className="App">
      <NavBar/>
      <Routes>
        {/* public routes */}
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/unauthorized" element={<Unauthorized/>} />

        <Route element={<RequireAuth/>}>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About/>} />
          <Route path="/profile" element={<Profile/>} />
          <Route path="/contact" element={<Contact/>} />
        </Route>
        
        <Route path="*" element={<Missing/>} />
    </Routes>
    </main>
  );
}

export default App;