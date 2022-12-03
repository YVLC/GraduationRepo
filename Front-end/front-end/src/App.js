import Register from './Register';
import Login from './Login';
import Home from './components/Home'
import RequireAuth from './components/RequireAuth';
import { Routes, Route } from 'react-router-dom';
function App() {

  return (
    <main className="App">
      <Routes>
        {/* public routes */}
        <Route path="/login" element={<Login />} />
        <Route path="register" element={<Register />} />
        <Route element={<RequireAuth />}>
          <Route path="/" element={<Home />} />
        </Route>
    </Routes>
    </main>
  );
}

export default App;