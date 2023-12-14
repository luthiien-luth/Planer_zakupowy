import Header from '../Header';
import Footer from './Footer';

function Layout({ children }) {
    return (
        <>
            <Header title="Planer zakupowy" /> {children}
            <Footer />
        </>
    );
}

export default Layout;
