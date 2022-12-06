import Register from './components/Registration/Register';
import Login from './components/Registration/Login';
import Home from './components/Pages/Home'
import About from './components/Pages/About'
import Blog from './components/Pages/Blog'
import Contact from './components/Pages/Contact'
import { Routes, Route } from 'react-router-dom';
import NavBar from './components/NavBar';
function App() {

  return (
    <main className="App">
      <NavBar/>
      <Routes>
        {/* public routes */}
        <Route path="/login" element={<Login />} />
        <Route path="register" element={<Register />} />
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About/>} />
        <Route path="/blog" element={<Blog/>} />
        <Route path="/contact" element={<Contact/>} />

    </Routes>
    </main>
  );
}

export default App;