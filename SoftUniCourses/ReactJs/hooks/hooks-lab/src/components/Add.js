import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import { useRef, useState } from 'react';
import useForm from '../hooks/useForm';

export const Add = () => {

    const { formValues, onChangeHandler } = useForm({
        text: '',
    });
    const submitForm = (e) => {
        e.preventDefault();
        console.log(formValues);
    }
    return (

        <Modal show={true}>
            <Modal.Header closeButton>
                <Modal.Title>Add todo</Modal.Title>
            </Modal.Header>

            <Modal.Body>
                <Form onSubmit={submitForm}>
                    <Form.Group className="mb-3" >
                        <Form.Label>Todo</Form.Label>
                        <Form.Control type="text" placeholder="Enter type here" name="text" onChange={onChangeHandler} value={formValues.text} />
                    </Form.Group>
                    <Button variant="primary" type="submit" >Add</Button>

                </Form>
            </Modal.Body>

            <Modal.Footer>
                <Button variant="secondary">Close</Button>
            </Modal.Footer>
        </Modal>
    );
}