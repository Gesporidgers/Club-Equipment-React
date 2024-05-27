import { useEffect, useState } from 'react';

function Light() {
    var [items, setItems] = useState();

    items = populateData();

    const content =
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Наименование</th>
                    <th>Количество</th>
                </tr>
            </thead>
            <tbody>
                {items.map(item =>
                    <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{item.name}</td>
                        <td>{item.quantity}</td>
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

    async function populateData() {
        
        const response = await fetch('lightds');
        const data = await response.json();
        return data;
    }
}

export default Light;

