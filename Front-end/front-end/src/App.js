import Register from './Register';
import Login from './Login';
import { Routes, Route } from 'react-router-dom';
function App() {

  return (
    <main className="App">
      <Routes>
        {/* public routes */}
        <Route path="/" element={<Login />} />
        <Route path="register" element={<Register />} />
    </Routes>
    </main>
  );
}

export default App;