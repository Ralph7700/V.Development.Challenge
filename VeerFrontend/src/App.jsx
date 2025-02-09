import { AuthContextProvider } from "./context/AuthContext"
import AppRouter from "./router/AppRouter"
import MainLayout from "./layouts/MainLayout"
import { RouterProvider } from "react-router-dom"

function App() {

  return (
    <>
        <AuthContextProvider>
          <MainLayout>
            <RouterProvider router={AppRouter}></RouterProvider>
          </MainLayout>
        </AuthContextProvider>
    </>
  )
}

export default App
