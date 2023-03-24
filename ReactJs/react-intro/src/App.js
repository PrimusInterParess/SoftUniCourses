import './App.css';
import Logo from './components/Logo';
import Paragraph from './components/Paragraph';
import Anchor from './components/Anchor';

function App() {
  return (
    <div className="App">
      <header className="App-header">
       <Logo/>
        <Paragraph/>
       <Anchor/>
        <section>
          <h1>DAni is here!</h1>
        </section>
      </header>
    </div>
  );
}

export default App;
