import { useEffect, useState } from 'react';
import './App.css';

const pages = [
    {
        url: '/light',
        text:'Световое оборудование',
    },

    {
        url: '/sound',
        text: 'Звуковое оборудование',
    },

    {
        url: '/video',
        text: 'Фото-Видео оборудование',
    },

    {
        url: '/DMX',
        text: 'DMX кабло',
    },

    {
        url: '/sound-cable',
        text: 'Звуковое кабло',
    },

    {
        url: '/video-cable',
        text: 'Видео кабло',
    },
    {
        url: '/Power',
        text: 'Питание',
    },
]

function App() {
    return (
        <>
            <meta charSet="UTF-8"/>
            <img src="logo.svg" alt="" width="695" height="190" />
            <h1>WELCOME</h1>
            <h3>А это наш сайт с перечнем оборудования</h3>
            <hr />
            {pages.map(page =>
                <div>
                <a href={page.url}><button>{page.text}</button></a>
                </div>
            )}

            
        </>
    );


}


export default App;