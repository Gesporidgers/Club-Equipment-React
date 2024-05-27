import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import {
    createBrowserRouter,
    RouterProvider,
} from "react-router-dom";
import Light from './Pages/Light.jsx';
import Sound from './Pages/Sound.jsx';
import DMX from './Pages/DMX.jsx';
import Video from './Pages/Video.jsx';
import Powercon from './Pages/Powercon.jsx';
import Video_cable from './Pages/Video_cable.jsx';
import Sound_cable from './Pages/Sound_cable.jsx';


const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        
    },
    {
        path: "/light",
        element: <Light/>,
    },
    {
        path: "/sound",
        element: <Sound/>,
    },
    {
        path: "/DMX",
        element: <DMX/>,
    },
    {
        path: "/Power",
        element: <Powercon/>,
    },
    {
        path: "/sound-cable",
        element: <Sound_cable/>,
    },
    {
        path: "/video-cable",
        element: <Video_cable/>,
    },
    {
        path: "/video",
        element: <Video/>,
    },
    {
        path: "*",
        element: <NotFoundPage/>,
    }
]);

ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <RouterProvider router={router} />
    </React.StrictMode>,
);

export function NotFoundPage() {
    return (
        <>
            <meta charSet="UTF-8" />
            <h1>404</h1>
            <div />
            <h2>Такой страницы не существует! Проверьте правильность введённого адреса</h2>
        </>
    );
}