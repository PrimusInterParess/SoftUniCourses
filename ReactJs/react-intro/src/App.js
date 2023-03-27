import './App.css';
import Logo from './components/Logo';
import Paragraph from './components/Paragraph';
import Anchor from './components/Anchor';
import Counter from './components/Counter';
function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Logo />
        <Paragraph />
        <Anchor />
        <section>
          <Counter start={0}/>
        </section>
      </header>
    </div>
  );
}

export default App;
