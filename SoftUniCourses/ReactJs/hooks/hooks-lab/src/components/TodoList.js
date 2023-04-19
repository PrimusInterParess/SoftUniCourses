import Table from 'react-bootstrap/Table';
import { TableHead } from './TableHead';
import { TableRow } from './TableRow';

export const TodoList=({todos,onChangeState})=>{
    return (
        <Table striped bordered hover>
            <TableHead/>
      <tbody>
      {todos.map(td=> <TableRow key={td._id} todo={td} onChangeState={onChangeState} />)}
      </tbody>
    </Table>
    );
}