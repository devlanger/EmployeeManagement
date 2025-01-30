import React, { useState } from 'react';

interface SearchBarProps {
    onSearch: (query: string) => void;
}

const SearchBar: React.FC<SearchBarProps> = ({ onSearch }) => {
    const [query, setQuery] = useState<string>('');

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const newQuery = e.target.value;
        setQuery(newQuery);
        onSearch(newQuery);  // Trigger search on every input change
    };

    return (
        <div className="search-bar">
            <input
                className="form-control"
                type="text"
                value={query}
                onChange={handleInputChange}
                placeholder="Search..."
                aria-label="Search input"
            />
        </div>
    );
};

export default SearchBar;
