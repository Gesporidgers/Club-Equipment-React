import { useEffect, useState } from 'react';
import axios from 'axios'
function Light() {
    var [items, setItems] = useState([]);
    
    useEffect(() => {
        axios.get('lightds').then((resp) => {
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
                        <td><button onClick={() => { delIt(item.id); setItems(items.filter(a => a.id != item.id)); } } >Delete</button></td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <>
            <h1>LIGHT</h1>
            {content }


        </>
    );

    function delIt(id) {
        axios.delete('lightds/' + id);
        
    }

    
}

export default Light;

