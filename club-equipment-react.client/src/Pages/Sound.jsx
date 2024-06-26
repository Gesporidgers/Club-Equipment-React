﻿import { useEffect, useState } from 'react';
import axios from 'axios'
import Modal from './Modal';
function Sound() {
    var [items, setItems] = useState([]);
    var [showModal, setShowModal] = useState(false);

    const toggleModal = () => { setShowModal(!showModal); };

    useEffect(() => {
        axios.get('api/audiods').then((resp) => {
            const allPersons = resp.data;
            setItems(allPersons);
        });
    }, [setItems]);


    const content =
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Наименование</th>
                    <th>Количество</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {items.map(item =>
                    <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{item.name}</td>
                        <td>{item.quantity}</td>
                        <td><button onClick={() => { delIt(item.id); setItems(items.filter(a => a.id != item.id)); }} >Delete</button></td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <>
            <Modal show={showModal} onCloseButtonClick={toggleModal} onAddButtonClick={() => { toggleModal(); addNew(); }} />
            <h1>SOUND</h1>
            {content}

            <footer>
                <button onClick={toggleModal}>+</button>
            </footer>
        </>

    );

    function delIt(id) {
        axios.delete('api/audiods/' + id);

    }

    function addNew() {
        axios.post('api/audiods', {
            id: 0,
            name: document.getElementById("nm").value,
            quantity: document.getElementById("qty").value,
        }).then(resp => {
            const dt = resp.data;
            setItems([...items, dt]);
        });

    }
}

export default Sound;

