import './App.css';
import Footer from './components/Footer';
import Header from './components/Header';
import UserList from './components/UserList';

function App() {
  return (
    <>
      <Header />
      <main className="main">
        <UserList />
      </main>
      <Footer />
    </>
  );
}

export default App;
