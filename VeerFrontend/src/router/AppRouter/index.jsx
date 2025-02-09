import { lazy } from "react"
import { BrowserRouter, Routes, Route, createBrowserRouter, createRoutesFromElements } from "react-router-dom"
import AuthenticatedRoute from "../AuthenticatedRoute";
import BaseRouteRedirect from "../BaseRouteRedirect";
import { homePageLoader } from "../../pages/Home";
import ErrorElement from "../../components/ErrorElement";

const HomePage = lazy(() => import("../../pages/Home"));
const LoginPage = lazy(()=> import("../../pages/Login"));

const AppRouter = createBrowserRouter(
    createRoutesFromElements(
            <>
            <Route path="/" errorElement={<ErrorElement/>}>
                <Route index element={<BaseRouteRedirect/>}/>
                <Route path="/login" element={<LoginPage />}/>
                <Route path="/home" element={<AuthenticatedRoute/>} >
                    <Route index element={<HomePage/>} loader={homePageLoader} />
                </Route>
            </Route>
            </>

    )
)

export default AppRouter