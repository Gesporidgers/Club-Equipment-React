import { useEffect, useState } from 'react';
import axios from 'axios'
import ModalCable from './ModalCable';

function Powercon() {
    var [items, setItems] = useState([]);
    var [showModal, setShowModal] = useState(false);

    const toggleModal = () => { setShowModal(!showModal); };

    useEffect(() => {
        axios.get('api/powercon').then((resp) => {
            const allPersons = resp.data;
            setItems(allPersons);
        });
    }, [setItems]);


    const content =
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Тип</th>
                    <th>Длина</th>
                    <th>Количество</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {items.map(item =>
                    <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{item.type}</td>
                        <td>{item.length} метров</td>
                        <td>{item.quantity}</td>
                        <td><button onClick={() => { delIt(item.id); setItems(items.filter(a => a.id != item.id)); }} >Delete</button></td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <>
            <ModalCable show={showModal} onCloseButtonClick={toggleModal} type='pwr' onAddButtonClick={() => { toggleModal(); addNew(); }} />
            <h1>Питание</h1>
            {content}

            <footer>
                <button onClick={toggleModal}>+</button>
            </footer>
        </>

    );

    function delIt(id) {
        axios.delete('api/powercon/' + id);

    }

    function addNew() {
        axios.post('api/powercon', {
            id: 0,
            type: document.getElementById("type").value,
            length: document.getElementById("length").value,
            quantity: document.getElementById("qty").value,
        }).then(resp => {
            const dt = resp.data;
            setItems([...items, dt]);
        });

    }
}

export default Powercon;

