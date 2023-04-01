import './App.css';
import FilterableProductTable from './components/FilterableProductTable/FilterableProductTable';
import pr from './state';

export default function App() {
  return (
    <FilterableProductTable products={pr} />
  );
}

